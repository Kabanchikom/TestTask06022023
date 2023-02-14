const baseUrl = process.env.VUE_APP_ROOT_API;

const login = async (username, password) =>
    await fetch(`${baseUrl}/login?` + new URLSearchParams({
        username: username,
        password: password,
    }), {
        method: 'POST',
        mode: 'cors'
    }).then(async response => {
        const isJson = response.headers.get('content-type')?.includes('application/json');
        const data = isJson ? await response.json() : null;

        if (!response.ok) {
            const error = (data && data.message) || response.status;
            return Promise.reject(error);
        }

        return data;
    });

export default {
    login
}
